import React, { useCallback, useMemo, useState } from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import Avatar from '@material-ui/core/Avatar';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import PersonAddDisabledIcon from '@material-ui/icons/PersonAddDisabled';
import BlogEditor from './BlogEditor';
import { Button } from './Components';
import CardActionArea from '@material-ui/core/CardActionArea';


const useStyles = makeStyles((theme) => ({
    markdown: {
        ...theme.typography.body2,
        padding: theme.spacing(3, 0),
    },
    root: {
        display: 'flex',
        '& > *': {
            margin: theme.spacing(1),
        },
    },
    avatar: {
        marginBottom: theme.spacing(2)
    },
}));


export default function Main(props) {
    const classes = useStyles();
    const { posts, title } = props;
    const following = false;
    return (
        <Grid item xs={12} md={8}>
            <Grid
                container
                spacing={1}
                className={classes.avatar}
                direction="row"
                justify="flex-start"
                alignItems="center">
                <Grid item >
                    <Avatar alt="Remy Sharp" />
                </Grid>
                <Grid item>
                    <Typography variant="subtitle1" color="textSecondary">
                        Remy Sharp
                    </Typography>
                </Grid>
                <Grid item>
                    <CardActionArea>
                        <Button>
                            {following ?
                                <PersonAddDisabledIcon color="primary" /> :
                                <PersonAddIcon color="primary" />}
                        </Button>
                    </CardActionArea>
                 </Grid>
            </Grid>
                <Divider />
                <BlogEditor />
        </Grid>
    );
}



Main.propTypes = {
    posts: PropTypes.array,
    title: PropTypes.string,
};