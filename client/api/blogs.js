import Fetch from "../helpers/Fetch";

export async function getBlog(pk) {
    var res = await Fetch("/readers/" + pk, "get");
    return res;
}

export async function getWriterBlog(pk) {
    var res = await Fetch("/writers/" + pk, "get",null, true);
    return res;
}

export async function getLatestBlogs() {
      var res = await Fetch("/readers/latest", "get");
    return res;
}

export async function getBlogsByTag(tagPk) {
    var res = await Fetch("/readers/" + tagPk, "get");
    return res;

}

export async function updateBlog(blog) {
    var res = await Fetch("/writers/" + blog.pk, "put",blog,true);
    return res;
}

export async function createBlog(blog) {
    var res = await Fetch("/writers/", "post", blog, true);
    return res;
}
