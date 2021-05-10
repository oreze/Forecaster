const menuButton = document.querySelector('.menu-btn');
const navigation = document.querySelector('nav');
const menuNav = document.querySelector('.nav-list')
const navItems = document.querySelectorAll('.nav-list__item');
let menuOpened = false;

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