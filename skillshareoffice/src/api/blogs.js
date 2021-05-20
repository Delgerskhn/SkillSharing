import Fetch from "./fetch";

export async function getBlogsByStatus(status) {
    var res = await Fetch('/office/blogs/status/' + status, 'get', null, true)
    return res
}