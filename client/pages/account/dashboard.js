import React, { useEffect } from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';
import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import FeaturedPost from '../../components/blogs/FeaturedPost';
import { useRouter } from 'next/router';
import { constBlog } from '../../shared/constants';
import { getBlogsByStatus } from '../../api/blogs';
import { useAppContext } from '../../context/AppContext';

function TabPanel(props) {
    const { children, value, index, ...other } = props;

    return (
        <div
            role="tabpanel"
            hidden={value !== index}
            id={`simple-tabpanel-${index}`}
            aria-labelledby={`simple-tab-${index}`}
            {...other}
        >
            {value === index && (
                <Box p={3}>
                    <Typography>{children}</Typography>
                </Box>
            )}
        </div>
    );
}

const featuredPosts = [
    {
        title: 'Featured post',
        date: 'Nov 12',
        description:
            'This is a wider card with supporting text below as a natural lead-in to additional content.',
        image: 'https://source.unsplash.com/random',
        imageText: 'Image Text',
    },
    {
        title: 'Post title',
        date: 'Nov 11',
        description:
            'This is a wider card with supporting text below as a natural lead-in to additional content.',
        image: 'https://source.unsplash.com/random',
        imageText: 'Image Text',
    },
];
TabPanel.propTypes = {
    children: PropTypes.node,
    index: PropTypes.any.isRequired,
    value: PropTypes.any.isRequired,
};

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
    },
}));
export default function Dashboard() {
    const classes = useStyles();
    const router = useRouter()
    const [status, setStatus] = React.useState(0);
    const [posts, setPosts] = React.useState([])
    const { setIsLoading } = useAppContext()


    useEffect(() => {
        const { query } = router
        query.status = parseInt(query.status)
        if (Number.isInteger(query.status)) {
            handleChange(null, query.status - 1)
        } else handleChange(null, 0)
    }, [router.query])

    const fetchPosts = async (status) => {
        setIsLoading(true)
        var res = await getBlogsByStatus(status)
        setIsLoading(false)
        setPosts(res)
    }

    const handleChange = (event, newValue) => {
        fetchPosts(newValue+1)
        setStatus(newValue);
    };

    return (
        <div className={classes.root}>
            <Paper className={classes.root}>
                <Tabs
                    value={status}
                    onChange={handleChange}
                    indicatorColor="primary"
                    textColor="primary"
                    centered
                >
                    <Tab label="Pending" />
                    <Tab label="Published" />
                    <Tab label="Declined" />
                    <Tab label="Draft"  />
                </Tabs>
            </Paper>
            <Grid mt={3} container spacing={4}>
                    {posts.map((post) => (
                        <FeaturedPost key={post.pk} post={post} hasController/>
                    ))}
                </Grid>
            
        </div>
        );
}