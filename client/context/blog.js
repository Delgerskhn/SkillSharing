import * as React from 'react'
import { useState } from 'react'
import { createBlog, getWriterBlog, updateBlog } from '../api/blogs'
import { populateBlogModel } from '../helpers/populateBlogModel'
import { useAppContext } from './AppContext'


const BlogContext = React.createContext()
function useBlogContext() {
    const context = React.useContext(BlogContext)
    if (!context) {
        throw new Error(`useBlogContext must be used within a BlogProvider`)
    }
    return context
}
function BlogProvider(props) {
    const [blog, setBlog] = useState({});
    const [tags, setTags] = useState([]);
    const [content, setContent] = useState(null);
    const [autoSaveAlertVisible, setVisible] = useState(false);

    const { setIsLoading } = useAppContext();

    //save tag state
    const onTagSelect = tags => {
        console.log(tags);

        setTags(tags);
    };

    const saveDraft = async () => {
        let populatedBlog = populateBlogModel(content, tags);
        populatedBlog.pk = blog.pk;
        if (blog?.pk) {
            await updateBlog(populatedBlog);
        } else {
            var res = await createBlog(populatedBlog);
            if (res?.content) res.content = JSON.parse(res.content);
            setBlog(res);
        }
        console.log(populatedBlog);
        setVisible(true);
    };

    //save content state
    const onNonInteractiveEditor = async content => {
        console.log("no interact", content);
        setContent(content);
    };

    //fetch model blog
    const fetchBlog = async (blogPk) => {
        let blogToStub = {};

        if (blogPk) {
            setIsLoading(true);
            blogToStub = await getWriterBlog(blogPk);
            setIsLoading(false);
        }
        if (blogToStub?.content)
            blogToStub.content = JSON.parse(blogToStub.content);
        setBlog(blogToStub);
    };

   

    //update model blog on content or tags change
    React.useEffect(
        () => {
            if (content || tags.length) saveDraft();
        },
        [content, tags]
    );

    const value = {
        autoSaveAlertVisible,
        setVisible,
        blog,
        onNonInteractiveEditor,
        onTagSelect,
        fetchBlog
    };
    return <BlogContext.Provider value={value} {...props} />
}
export { BlogProvider, useBlogContext }