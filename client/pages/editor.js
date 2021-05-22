import React, { useEffect, useState } from "react";
import { withAuth } from "../shared/withAuth";
import Grid from "@material-ui/core/Grid";
import BlogEditor from "../components/editor/BlogEditor";
import TagSearch from "../components/forms/TagSearch";
import { useBlogContext } from "../context/blog";
import { AutoSaveAlert } from "../components/Alert";

function Editor({ blogPk }) {
  const {
    autoSaveAlertVisible,
    setVisible,
    blog,
    onNonInteractiveEditor,
      onTagSelect,
      fetchBlog
  } = useBlogContext();
    useEffect(() => {
        fetchBlog(blogPk);
    }, []);
  return (
    <main>
        <AutoSaveAlert
          isVisible={autoSaveAlertVisible}
          setIsVisible={setVisible}
        />
        <Grid container spacing={5} p={4}>
          <Grid item xs={12}>
            <BlogEditor
              content={blog.content}
              readOnly={false}
              onNonInteractiveEditor={onNonInteractiveEditor}
            />
          </Grid>
          <Grid item>
            <TagSearch
              onSelectCallback={onTagSelect}
              defaultValue={blog.tags}
            />
          </Grid>
        </Grid>
    </main>
  );
}

export async function getServerSideProps({ query }) {
  let { pk } = query;
  if (pk === undefined) pk = null;
  return {
    props: {
      blogPk: pk
    }
  };
}

export default withAuth(Editor);
