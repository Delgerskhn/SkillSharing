const SaveUser = (user) => {
    window.localStorage.setItem('user', JSON.stringify(user))
}

const RemoveUser = () => {
    window.localStorage.removeItem('user')
}

const GetUser =  () => {
    var u = window.localStorage.getItem('user');
    try {
        u = JSON.parse(u);
    } catch {
        return null;
    }
    return u;
}

export { GetUser, SaveUser, RemoveUser }