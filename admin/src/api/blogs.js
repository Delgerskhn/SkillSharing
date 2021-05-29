import Fetch from "./fetch";

export async function getBlogsByStatus(status) {
  try {
    var res = await Fetch("/office/blogs/status/" + status, "get", null, true);
    return res;
  }catch(e){
    return []
  }
}

export async function updateBlogStatus(blogPk, statusPk) {
  var res = await Fetch(`/office/blogs/change?blogPk=${blogPk}&statusPk=${statusPk}`, 'post', null, true)
  return res
}