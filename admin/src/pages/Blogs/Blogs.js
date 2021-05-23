import React, { useEffect } from 'react';
import getParam from '../../utils/query-string';
import BlogsLV from '../../views/blogs-listview';

import './Blogs.scss';

export default () => {
   

   
    return (
        < React.Fragment >
        <h2 className={'content-block'}>Blogs</h2>
        <div className={'content-block'}>
            <div className={'dx-card responsive-paddings'}>
                    <BlogsLV />
          </div>
        </div>
      </React.Fragment>
);
}
