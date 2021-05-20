import React, { useEffect } from 'react';
import { useHistory  } from "react-router-dom"
import getParam from '../../utils/query-string';
import BlogsLV from '../../views/blogs-listview';

import './Blogs.scss';

export default () => {
    const history = useHistory()

    useEffect(() => {
        let p = getParam(history.location.search, 'status')

    }, [])
    return (
        < React.Fragment >
        <h2 className={'content-block'}>Blogs</h2>
        <div className={'content-block'}>
            <div className={'dx-card responsive-paddings'}>
                <BlogsLV/>
          </div>
        </div>
      </React.Fragment>
);
}
