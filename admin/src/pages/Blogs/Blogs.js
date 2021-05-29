import React, { useEffect, useState } from 'react';
import { withRouter } from 'react-router';
import { BlogsProvider } from '../../contexts/blog';
import { constBlog } from '../../utils/constants';
import getParam from '../../utils/query-string';
import BlogsLV from '../../views/blogs-listview';

import './Blogs.scss';

function Blogs(props) {
  const [status, setStatus] = useState(1)

  useEffect(
    () => {
      let p = getParam(props.location.search, "status");
      if(p) setStatus(parseInt(p))
    },
    [props.location])

    const getStatusNameByPk =(status)=>{
      for(let e of Object.entries(constBlog.State))
        if(e[1] === status) return e[0]
    }
   
    return (
        <React.Fragment >
        <BlogsProvider>
        <h2 className={'content-block'}>{getStatusNameByPk(status)} Blogs</h2>
        <div className={'content-block'}>
            <div className={'dx-card responsive-paddings'}>
                    <BlogsLV />
          </div>
        </div>
        </BlogsProvider>
      </React.Fragment>
);
}
export default withRouter(Blogs)