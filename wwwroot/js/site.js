const menuButton = document.querySelector('.menu-btn');
const navigation = document.querySelector('nav');
const menuNav = document.querySelector('.nav-list')
const navItems = document.querySelectorAll('.nav-list__item');
const selectList = document.querySelectorAll('.select-box');
const selectOptionLabelsList = document.querySelectorAll('.select-box > .select-box__list > li');
let menuOpened = false;

const toggleSelect = (x) => {
    if (!x.classList.contains('open')) {
        x.classList.add('open');
    }
    else {
        x.classList.remove('open');
    }
}

// Remove current checked attribute and set it to new checked item
const chooseOption = (element, selectBox) => {
    const optionID = element.firstElementChild.getAttribute('for');
    const inputs = selectBox.firstElementChild.getElementsByTagName('input');
    const inputList = Array.prototype.slice.call(inputs);
    
    // Replace current input with new
    const currentInput = inputList.find(x => x.checked == true);
    currentInput.removeAttribute('checked')
    const searchedInput = inputList.find(x => x.getAttribute('value') == optionID.toString());
    searchedInput.setAttribute('checked', "");
}

const toggleMenu = () => {
    if (!menuOpened) {
        menuButton.classList.add('open');
        navigation.classList.add('open');
        menuNav.classList.add('open');
        navItems.forEach(x => x.classList.add('open'));
        
        menuOpened = true;
    } else {
        menuButton.classList.remove('open');
        navigation.classList.remove('open');
        menuNav.classList.remove('open');
        navItems.forEach(x => x.classList.remove('open'));
        
        menuOpened = false;
    }
}

menuButton.addEventListener('click', toggleMenu);
selectList.forEach(x => x.addEventListener('click', toggleSelect.bind(null, x)));
selectOptionLabelsList.forEach(x => x.addEventListener('click', chooseOption.bind(null, x, x.parentNode.parentNode.parentNode)))
