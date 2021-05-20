const Fetch = async (path, method, body, secure = false) => {
    var headers = new Headers();
    if (secure) headers.append("Authorization", `Bearer ${getUser().token}`);
    if (method.toUpperCase() != "GET") headers.append("Content-Type", "application/json");

    var options = {
        method: method,
        redirect: 'follow',
        headers: headers
    };
    if (body) options.body = JSON.stringify(body);
    var req = await fetch(`${process.env.REACT_APP_API_HOST}/api${path}`, options)
    var res = await req.text();
    try {
        res = JSON.parse(res);
    } catch (err) {
    }
    if (req.ok) return res
    throw "Error"
}

export default Fetch