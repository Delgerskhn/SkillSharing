export default function getParam(search, param) {
    const params = new URLSearchParams(search);
    return params.get(param)
}