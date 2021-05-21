import React from "react";
import { withAuth } from "../shared/withAuth";
import Grid from "@material-ui/core/Grid";
import BlogEditor from "../components/editor/BlogEditor";
import TagSearch from "../components/forms/TagSearch";
import { BlogProvider } from "../context/blog";

function Editor({ blog }) {
  const onTagSelect = tags => {
    console.log(tags);
    };

    const onDeactiveEditor = content => {
        console.log(content)
    }
  return (
    <main>
      <Grid container spacing={5} p={4}>
        <Grid item xs={12}>
                  <BlogEditor readOnly={false} onDeactiveEditor={onDeactiveEditor}/>
        </Grid>
        <Grid item>
          <TagSearch onSelectCallback={onTagSelect} />
        </Grid>
      </Grid>
    </main>
  );
}

export async function getServerSideProps({ query }) {
    console.log('fetch blog')
    return {
        props: {
            blog: {}
        }
    }
}

export default withAuth(Editor);
