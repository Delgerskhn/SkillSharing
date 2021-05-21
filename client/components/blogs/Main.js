import React, { useCallback, useMemo, useState } from "react";
import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/core/styles";
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import Divider from "@material-ui/core/Divider";
import Avatar from "@material-ui/core/Avatar";
import PersonAddIcon from "@material-ui/icons/PersonAdd";
import PersonAddDisabledIcon from "@material-ui/icons/PersonAddDisabled";
import BlogEditor from "./BlogEditor";
import { Button } from "./Components";
import CardActionArea from "@material-ui/core/CardActionArea";
import Box from "@material-ui/core/Box";

const useStyles = makeStyles(theme => ({
  markdown: {
    ...theme.typography.body2,
    padding: theme.spacing(3, 0)
  },
  root: {
    display: "flex",
    "& > *": {
      margin: theme.spacing(1)
    }
  },
  avatar: {
    marginBottom: theme.spacing(2)
  }
}));

export default function Main(props) {
  const classes = useStyles();
  const following = false;
  return (
    <Grid item xs={12} md={8}>
      <Box
        display="flex"
        justifyContent="flex-start"
        direction="row"
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
  );
}
