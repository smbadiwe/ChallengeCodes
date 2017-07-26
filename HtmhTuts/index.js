'use strict';

function loadScript(src) {
    return new Promise(function(resolve, reject) {
        let script = document.createElement('script');
        script.src = src;
        script.onload = () => resolve(script);
        script.onerror = () => reject(new Error("Failed!"));
        document.head.append(script);
    });
}

function delay(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

function func(a, b) {
  alert(`Cool, the script ${a + b} is loaded`);
  alert( _ ); // function declared in the loaded script
}

///////////////////////
class HttpError extends Error {
  constructor(response) {
    super(`${response.status} for ${response.url}`);
    this.name = 'HttpError';
    this.response = response;
  }
}

async function loadJson(url) {
    let response = await fetch(url);
  
    if (response.status == 200) {
        return response.json();
    }   
    throw new HttpError(response);
}

// Ask for a user name until github returns a valid user
async function demoGithubUser() {
    while (true) {
        let name = prompt("Enter a name?", "iliakan");

        try {
            let user = await loadJson(`https://api.github.com/users/${name}`);

            alert(`Full name: ${user.name}.`);
            return user;
        } catch (err) {
            if (err instanceof HttpError && err.response.status == 404) {
                alert("No such user, please reenter.");
            } else {
                throw err;
            }
        };
    }
}

let range = {
  from: 1,
  to: 5,
  // 1. call to for..of initially calls this
  [Symbol.iterator]: function() {

        // 2. ...it returns the iterator:
        return {
            current: this.from, // start at "range.from",
            last: this.to,      // end at "range.to"

            // 3. next() is called on each iteration by for..of
            next() {
                if (this.current <= this.last) {
                    // 4. it should return the value as an object {done:.., value :...}
                    return { done: false, value: this.current++ };
                } else {
                    return { done: true };
                }
            }
        };
    }
};
let arr = Array.from(range);
alert(arr);
// for (let num of range) {
//   alert(num); // 1, then 2, 3, 4, 5
// }