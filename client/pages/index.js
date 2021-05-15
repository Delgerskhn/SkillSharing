import * as React from 'react';
import Container from '@material-ui/core/Container';
import Typography from '@material-ui/core/Typography';
import Box from '@material-ui/core/Box';
import ProTip from '../src/ProTip';
import Link from '../src/Link';
import Copyright from '../src/Copyright';
import Grid from '@material-ui/core/Grid';
import FeaturedPost from '../components/blogs/FeaturedPost';
import { Button } from '../components/blogs/Components';
import { makeStyles } from '@material-ui/core/styles';


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
const useStyles = makeStyles((theme) => ({
    heroContent: {
        backgroundColor: theme.palette.background.paper,
        padding: theme.spacing(8, 0, 6),
    }
}));

export default function Index() {
    const classes = useStyles();

  return (
      <main>

          <div className={classes.heroContent}>
              <Container maxWidth="sm">
                  <Typography component="h1" variant="h2" align="center" color="textPrimary" gutterBottom>
                      Watchu lookinfo?
            </Typography>
                  <Typography variant="h5" align="center" color="textSecondary" paragraph>
                      Something short and leading about the collection below—its contents, the creator, etc.
                      Make it short and sweet, but not too short so folks don&apos;t simply skip over it
                      entirely.
            </Typography>
                  <div className={classes.heroButtons}>
                      <Grid container spacing={2} justify="center">
                          <Grid item>
                              <Button variant="contained" color="primary">
                                  Main call to action
                  </Button>
                          </Grid>
                          <Grid item>
                              <Button variant="outlined" color="primary">
                                  Secondary action
                  </Button>
                          </Grid>
                      </Grid>
                  </div>
              </Container>
          </div>

          <Grid container spacing={4}>
              {featuredPosts.map((post) => (
                  <FeaturedPost key={post.title} post={post} />
              ))}
          </Grid>
          
      </main>
  );
}
