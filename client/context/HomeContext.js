import * as React from 'react'


const featuredPosts = [
    {
        title: 'Featured post',
        date: 'Nov 12',
        description:
            'This is a wider card with supporting text below as a natural lead-in to additional content.',
        image: 'https://source.unsplash.com/random',
        imageText: 'Image Text',
    },
    {
        title: 'Post title',
        date: 'Nov 11',
        description:
            'This is a wider card with supporting text below as a natural lead-in to additional content.',
        image: 'https://source.unsplash.com/random',
        imageText: 'Image Text',
    },
];
const HomeContext = React.createContext()
function useHomeContext() {
    const context = React.useContext(HomeContext)
    if (!context) {
        throw new Error(`useHomeContext must be used within a HomeProvider`)
    }
    return context
}
function HomeProvider(props) {
    const [blogs, setBlogs] = React.useState(featuredPosts)
    const value = React.useMemo(() => [blogs, setBlogs], [blogs])
    return <HomeContext.Provider value={value} {...props} />
}
export { HomeProvider, useHomeContext }