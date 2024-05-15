document.addEventListener("DOMContentLoaded", (e) => {
   document.getElementById("section-2-lesson-HTML__cross_activ").addEventListener('click', (e) => {
    document.getElementById("test").classList.add('section-2-lesson_div_invisible_show')
   })

   document.getElementById("section-2-lesson-HTML__cross_no").addEventListener('click', (e) => {
    document.getElementById("test").classList.remove('section-2-lesson_div_invisible_show')
   })

   document.getElementById("section-2-lesson-HTML__cross_yes").addEventListener('click', (e) => {
    document.getElementById("test").classList.remove('section-2-lesson_div_invisible_show')
   })

   document.getElementById("section-2-lesson-HTML__cross_yes").addEventListener('click', (e) => {
    document.getElementById("big_test").classList.add('test')
   })
})