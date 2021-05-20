import { getUser, removeUser } from "./auth";

const Fetch = async (path, method, body, secure = false) => {
    var headers = new Headers();
    if (secure) headers.append("Authorization", `Bearer ${getUser().data.auth_token}`);
    if (method.toUpperCase() != "GET") headers.append("Content-Type", "application/json");

    var options = {
        method: method,
        redirect: 'follow',
        headers: headers
    };
    if (body) options.body = JSON.stringify(body);
    var req = await fetch(`${process.env.REACT_APP_API_HOST}/api${path}`, options)
    if (req.status === 401) removeUser()

    var res = await req.text();
    try {
        res = JSON.parse(res);
    } catch (err) {
    }
    console.log(res)
    if (req.ok) return res
    throw res
}

export default Fetch