import Fetch, { WrapResult } from "../helpers/Fetch";

export async function getAccountInfo() {
    try {
        var res = await Fetch('/account', 'get', null, true);
        return WrapResult(true, res)
    } catch (ex) {
        return WrapResult(false, ex)
    }
}

export async function withdrawSalary() {
    try {
        var res = await Fetch('/writers/withdraw', 'post', null, true);
        return WrapResult(true)
    } catch (ex) {
        return WrapResult(false,null,ex)
    }
}