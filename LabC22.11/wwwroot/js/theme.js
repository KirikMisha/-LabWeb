// Получаем текущую тему из сессии (если установлена)
const savedTheme = sessionStorage.getItem('theme');

// Устанавливаем тему при загрузке страницы
if (savedTheme) {
    document.body.classList.add(savedTheme);
} else {
    // По умолчанию: светлая тема
    document.body.classList.add('light-theme');
}

// Функция для переключения темы
function toggleTheme() {
    const currentTheme = document.body.classList.contains('light-theme') ? 'light-theme' : 'dark-theme';
    const newTheme = currentTheme === 'light-theme' ? 'dark-theme' : 'light-theme';

    // Устанавливаем новую тему
    document.body.classList.replace(currentTheme, newTheme);

    // Сохраняем тему в сессии
    sessionStorage.setItem('theme', newTheme);
}
