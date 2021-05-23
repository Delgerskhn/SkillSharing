import defaultUser from '../utils/default-user';
import Fetch from './fetch';

export async function signIn(email, password) {
  try {
    // Send request
      var body = {
          email: email,
          password: password
      }
      var res = await Fetch('/auth/login', 'post', body, true);
      res.avatarUrl = defaultUser.avatarUrl
      saveUser(res)
    return {
      isOk: true,
        data: res
    };
  }
  catch(ex) {
    return {
      isOk: false,
      message: ex?.login_failure[0] || "Authentication failed"
    };
  }
}

export function saveUser(user) {
    localStorage.setItem('user', JSON.stringify(user))
}

export function removeUser() {
    localStorage.removeItem('user')
}

export function getUser() {
  try {
      // Send request
      var u = JSON.parse(localStorage.getItem('user'))
      
    return {
      isOk: true,
      data: u
    };
  }
  catch {
    return {
      isOk: false
    };
  }
}

export async function createAccount(email, password) {
  try {
    // Send request
    console.log(email, password);

    return {
      isOk: true
    };
  }
  catch {
    return {
      isOk: false,
      message: "Failed to create account"
    };
  }
}

export async function changePassword(email, recoveryCode) {
  try {
    // Send request
    console.log(email, recoveryCode);

    return {
      isOk: true
    };
  }
  catch {
    return {
      isOk: false,
      message: "Failed to change password"
    }
  }
}

export async function resetPassword(email) {
  try {
    // Send request
    console.log(email);

    return {
      isOk: true
    };
  }
  catch {
    return {
      isOk: false,
      message: "Failed to reset password"
    };
  }
}
