import Fetch from "../helpers/Fetch"

let tags = []

const createTag = async (tag) => {
    tags.push(tag)
    try {
        return await Fetch('/writers/tag', 'post', tag, true)
    } catch {
        return tag
    }
}

const fetchTags = async () => {
    try {
        tags = await Fetch('/readers/tags', 'get')
    } catch {
        tags = []
    }
}

const getTags = () => tags


export { getTags, createTag, fetchTags }