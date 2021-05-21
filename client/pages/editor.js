import React from "react";
import { withAuth } from "../shared/withAuth";
import Grid from "@material-ui/core/Grid";
import BlogEditor from "../components/editor/BlogEditor";
import TagSearch from "../components/forms/TagSearch";

function Editor() {
  return (
    <main>
      <Grid container spacing={5} p={4}>
        <Grid item xs={12}>
          <BlogEditor readOnly={false} />
              </Grid>
              <Grid item>
                  <TagSearch />
              </Grid>
      </Grid>
    </main>
  );
}

export default withAuth(Editor);
