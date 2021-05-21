import React, { useEffect, useState } from "react";
import { withAuth } from "../shared/withAuth";
import Grid from "@material-ui/core/Grid";
import BlogEditor from "../components/editor/BlogEditor";
import TagSearch from "../components/forms/TagSearch";
import { BlogProvider } from "../context/blog";
import { populateBlogModel } from "../helpers/populateBlogModel";
import { AutoSaveAlert } from "../components/Alert";
import { createBlog, getWriterBlog, updateBlog } from "../api/blogs";
import { useAppContext } from "../context/AppContext";

function Editor({ blogPk }) {

    const [blog, setBlog] = useState({});
    const [tags, setTags] = useState([]);
    const [content, setContent] = useState(null)
    const [autoSaveAlertVisible, setVisible] = useState(false);

    const { setIsLoading } = useAppContext()

    //save tag state
    const onTagSelect = tags => {
        setTags(tags);
    };

    const saveDraft = async () => {
        let populatedBlog = populateBlogModel(content, tags);
        populatedBlog.pk = blog.pk;
        if (blog?.pk) {
            await updateBlog(populatedBlog);
        } else {
            var res = await createBlog(populatedBlog);
            if (res?.content) res.content = JSON.parse(res.content)
            setBlog(res);
        }
        console.log(populatedBlog);
        setVisible(true);
    }

    //save content state
    const onNonInteractiveEditor = async content => {
        setContent(content)
    };

    //fetch model blog 
    const fetchBlog = async() => {
        let blogToStub = {};

        if (blogPk) {
            setIsLoading(true)
            blogToStub = await getWriterBlog(blogPk);
            setIsLoading(false)
        }
        if (blogToStub?.content) blogToStub.content = JSON.parse(blogToStub.content)
        setBlog(blogToStub)
    }

    useEffect(() => {
        fetchBlog()
    }, [])

    //update model blog on content or tags change
    useEffect(() => {
        if(content)
        saveDraft()
    }, [content, tags])

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
          <TagSearch onSelectCallback={onTagSelect} />
        </Grid>
      </Grid>
    </main>
  );
}

export async function getServerSideProps({ query }) {
    let { pk } = query;
    if(pk===undefined) pk = null
  return {
    props: {
      blogPk: pk
    }
  };
}

export default withAuth(Editor);
