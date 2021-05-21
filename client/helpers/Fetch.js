import { GetUser } from "./UserStore";

const Fetch = async (path, method, body, secure = false) => {
    var headers = new Headers();
    if (secure) headers.append("Authorization", `Bearer ${GetUser().auth_token}`);
    if(method.toUpperCase() != "GET") headers.append("Content-Type", "application/json");

    var options = {
        method: method,
        redirect: 'follow',
        headers: headers
    };
    if (body) options.body = JSON.stringify(body);
    var req = await fetch(`${process.env.NEXT_PUBLIC_API_HOST}${path}`, options)
    if (req.status == 500) throw "Unexpected error occured. Please try again."
    var res = await req.text();
    console.log(res)
    try {
        var temp = JSON.parse(res);
        res = temp;
    } catch (err) {
    }
    return res
}

export default Fetch