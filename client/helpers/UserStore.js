import Cookies from 'js-cookie'


const SaveUser = (user) => {
    Cookies.set('user', JSON.stringify(user), { expires: 7 });
}

const RemoveUser = () => {
    Cookies.remove('user')
}

const GetUser =  () => {
    var u = Cookies.get('user');
     u = JSON.parse(u);
    return u;
}

export { GetUser, SaveUser, RemoveUser }