import React from 'react'
import { withAuth } from '../shared/withAuth'
import Grid from '@material-ui/core/Grid';
import Main from '../components/blogs/Main';

function Editor() {
    return (
        <Grid container spacing={5} >
            <Main/>
        </Grid>
        );
}

export default withAuth(Editor)