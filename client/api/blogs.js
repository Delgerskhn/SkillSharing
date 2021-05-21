import Fetch from "../helpers/Fetch";

export async function getBlog(pk) {
    var res = await Fetch("/readers/" + pk, "get");
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
