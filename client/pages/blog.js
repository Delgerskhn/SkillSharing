import React, { useEffect } from "react";
import { useRouter } from "next/router";

import { makeStyles } from "@material-ui/core/styles";
import Grid from "@material-ui/core/Grid";
import GitHubIcon from "@material-ui/icons/GitHub";
import FacebookIcon from "@material-ui/icons/Facebook";
import TwitterIcon from "@material-ui/icons/Twitter";
import Sidebar from "../shared/Sidebar";
import Fetch from "../helpers/Fetch";
import { Avatar, Box, Divider, Typography } from "@material-ui/core";
import BlogEditor from "../components/editor/BlogEditor";

const useStyles = makeStyles(theme => ({
  mainGrid: {
    marginTop: theme.spacing(3)
  }
}));

const sidebar = {
  title: "About",
  description:
    "Etiam porta sem malesuada magna mollis euismod. Cras mattis consectetur purus sit amet fermentum. Aenean lacinia bibendum nulla sed consectetur.",
  archives: [
    { title: "March 2020", url: "#" },
    { title: "February 2020", url: "#" },
    { title: "January 2020", url: "#" },
    { title: "November 1999", url: "#" },
    { title: "October 1999", url: "#" },
    { title: "September 1999", url: "#" },
    { title: "August 1999", url: "#" },
    { title: "July 1999", url: "#" },
    { title: "June 1999", url: "#" },
    { title: "May 1999", url: "#" },
    { title: "April 1999", url: "#" }
  ],
  social: [
    { name: "GitHub", icon: GitHubIcon },
    { name: "Twitter", icon: TwitterIcon },
    { name: "Facebook", icon: FacebookIcon }
  ]
};

export default function Blog({ blog }) {
  const classes = useStyles();

  return (
    <main>
      <Grid container spacing={5} className={classes.mainGrid}>
        <Grid item xs={12} md={8}>
          <Box
                      display="flex"
                      justifyContent="flex-start"
                      direction="row"
                      mb={2}
            alignItems="center"
          >
            <Box mr={2}>
              <Avatar alt="Remy Sharp" />
            </Box>
            <Typography variant="subtitle1" color="textSecondary">
              Remy Sharp
            </Typography>
          </Box>

          <Divider />
          <BlogEditor />
        </Grid>

        <Sidebar
          title={sidebar.title}
          description={sidebar.description}
          archives={sidebar.archives}
          social={sidebar.social}
        />
      </Grid>
    </main>
  );
}

export async function getServerSideProps({ query }) {
  console.log(query);
  const { pk } = query;
  // Fetch data from external API
  var res = await Fetch("/readers/" + pk, "get");
  console.log(res);
  // Pass data to the page via props
  return { props: { blog: res } };
}
