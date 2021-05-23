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

export async function getBlogsByStatus(status) {
    var res = await Fetch("/writers/?Status=" + status, "get", null, true);
    if(!res?.length) return []
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

export async function publishBlog(blogPk) {
    try {
        var res = await Fetch("/writers/publish/" + blogPk, "post", null, true)
        return {
            Ok: true
        }
    } catch(ex) {
        return {
            Ok: false,
            Message: "An error occured!"
        }
    }
}

export async function deleteBlog(blogPk) {
    try {
        var res = await Fetch('/writers/' + blogPk, 'delete', null, true)
        return { Ok: true }
    } catch (ex) {
        return { Ok: false, Message: "An error occured!" }
    }
}