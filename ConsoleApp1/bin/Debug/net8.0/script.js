const user = document.getElementById("username");

if (user.textContent.includes("No Account")) {
    setTimeout(() => {
        user.textContent = "No account found!";
    }, 1500);
}

const bal = document.getElementById("bal");
let returnBal = bal.textContent;
let balIsHide = false;

bal.addEventListener('click', function() {
    if (balIsHide) {
        bal.textContent = returnBal;
        balIsHide = false;
    } else {
        bal.textContent = "****";
        balIsHide = true;
    }
});

const wallet = document.getElementById("wallet");
let wf = document.getElementById("wlf");
let isOpen = false;
wallet.addEventListener('click', function() {
    if (isOpen) {
        wf.classList.remove("open");
        setTimeout(() => {
            isOpen = false;
        },1200);
        
    } else {
        wf.classList.add("open");
        isOpen = true;
    }
});