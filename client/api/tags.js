import Fetch from "../helpers/Fetch"

let tags = []

const createTag = async (tag) => {
    tags.push(tag)
    await Fetch('/writers/tag', 'post', tag, true)
}

const fetchTags = async () => {
    tags = [
        { name: "The Shawshank Redemption", pk: 1994 },
        { name: "The Godfather", pk: 1972 },
        { name: "The Godfather: Part II", pk: 1974 },
        { name: "The Dark Knight", pk: 2008 }
    ];
}

const getTags = () => tags


export { getTags, createTag, fetchTags }