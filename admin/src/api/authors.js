import Fetch from "./fetch"

export async function getAuthors() {
    try{
        var res = await Fetch(`/office/authors`, 'get', null, true)
        return res
    } catch(e) {
        return []
    }
  }