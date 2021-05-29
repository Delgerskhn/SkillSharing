import React, { useState, useEffect, createContext, useContext, useCallback } from 'react';
import CustomStore from 'devextreme/data/custom_store';
import { getBlogsByStatus, updateBlogStatus } from '../api/blogs';

function BlogsProvider(props) {
  const [blogs, setBlogs] = useState([])

  const setBlogsByStatus = async (statusPk) =>{
      let res = await getBlogsByStatus(statusPk)
    setBlogs(res)
  }

  const updateStatus = (pk, statusPk) => {
      updateBlogStatus(pk, statusPk)
      let clone = [...blogs]
    let blog = clone.find(r=>r.pk === pk)
    blog.blogStatusPk=statusPk;
    setBlogs(clone)
  }

  return (
    <BlogsContext.Provider value={{ blogs, setBlogs, setBlogsByStatus, updateStatus }} {...props} />
  );
}

const BlogsContext = createContext({});
const useBlogs = () => useContext(BlogsContext);

export { BlogsProvider, useBlogs }
