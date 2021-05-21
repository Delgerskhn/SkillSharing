import * as React from 'react'
import { useState } from 'react'


const BlogContext = React.createContext()
function useBlogContext() {
    const context = React.useContext(BlogContext)
    if (!context) {
        throw new Error(`useBlogContext must be used within a BlogProvider`)
    }
    return context
}
function BlogProvider(props) {
    const [tags, setTags] = useState([])
    const onSaveDraft = (contentJson) => {

    }

    const value = {
        tags, 
        setTags,
        onSaveDraft
    };
    return <BlogContext.Provider value={value} {...props} />
}
export { BlogProvider, useBlogContext }