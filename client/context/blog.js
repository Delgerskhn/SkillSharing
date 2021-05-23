import React, { useState, useEffect, createContext, useContext, useCallback } from 'react';
import { useAppContext } from './app';

function BlogProvider(props) {
    const [blog, setBlog] = useState({})
    const { setIsLoading } = useAppContext();

    return (
        <BlogContext.Provider value={{ blog, setBlog }} {...props} />
    );
}

const BlogContext = createContext({});
const useBlogContext = () => useContext(BlogContext);

export { BlogProvider, useBlogContext }
