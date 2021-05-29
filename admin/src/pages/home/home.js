import React from 'react';
import AuthorsListview from '../../views/authors-listview';
import './home.scss';

export default () => (
  <React.Fragment>
    <h2 className={'content-block'}>Home</h2>
    <div className={'content-block'}>
        <AuthorsListview/>
    </div>
  </React.Fragment>
);
