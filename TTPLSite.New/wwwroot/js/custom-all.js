
jQuery(document).ready(function($) {
  $('.industry-slider').slick({
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 2000,
    arrows: false,
    responsive: [{
      breakpoint: 900,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 1
      }
    },
    {
       breakpoint: 600,
       settings: {
          arrows: false,
          slidesToShow: 1,
          slidesToScroll: 1
       }
    }]
});
});


  jQuery(document).ready(function($) {
        $('.slider-evolution').slick({
          dots: false,
          infinite: true,
          speed: 500,
          slidesToShow: 3,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          arrows: true,
          responsive: [{
            breakpoint: 900,
            settings: {
              slidesToShow: 2,
              slidesToScroll: 1
            }
          },
          {
             breakpoint: 600,
             settings: {
                arrows: true,
                slidesToShow: 1,
                slidesToScroll: 1
             }
          }]
      });
  });  
  


$(window).scroll(function() {
  if ($(this).scrollTop() > 1){  
      $('.section-2').addClass("sticky");
    }
    else{
      $('.section-2').removeClass("sticky");
    }
  });
  
  jQuery(document).ready(function($) {
        $('.slider-logo').slick({
          dots: false,
          infinite: true,
          speed: 500,
          slidesToShow: 4,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 1000,
          arrows: true,
          responsive: [{
            breakpoint: 1024,
            settings: {
              slidesToShow: 2,
              slidesToScroll: 1
            }
          },
          {
             breakpoint: 400,
             settings: {
                arrows: true,
                slidesToShow: 1,
                slidesToScroll: 1
             }
          }]
      });
  });
  
  
  jQuery(document).ready(function($) {
        $('.slider-success').slick({
          dots: true,
          infinite: true,
          speed: 500,
          slidesToShow: 1,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          arrows: false,
          responsive: [{
            breakpoint: 600,
            settings: {
              slidesToShow: 1,
              slidesToScroll: 1
            }
          },
          {
             breakpoint: 400,
             settings: {
                arrows: true,
                slidesToShow: 1,
                slidesToScroll: 1
             }
          }]
      });
  });
  
  
  
  jQuery(document).ready(function($) {
        $('.slider-reactjs').slick({
          dots: false,
          infinite: true,
          speed: 500,
          slidesToShow: 3,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          arrows: true,
          responsive: [{
            breakpoint: 1024,
            settings: {
              slidesToShow: 2,
              slidesToScroll: 1
            }
          },
          {
             breakpoint: 767,
             settings: {
                arrows: true,
                slidesToShow: 1,
                slidesToScroll: 1
             }
          }]
      });
  });  
  
  

  
  jQuery(document).ready(function($) {
      $('.slider-Testimonial').slick({
        dots: false,
        infinite: true,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
        arrows: true,
        responsive: [{
          breakpoint: 900,
          settings: {
            slidesToShow: 2,
            slidesToScroll: 1
          }
        },
        {
           breakpoint: 600,
           settings: {
              arrows: true,
              slidesToShow: 1,
              slidesToScroll: 1
           }
        }]
    });
  });
  
  
  
  $(document).ready(function(){ 
      $(window).scroll(function(){ 
          if ($(this).scrollTop() > 800) { 
              $('#scroll').fadeIn(); 
          } else { 
              $('#scroll').fadeOut(); 
          } 
      }); 
      $('#scroll').click(function(){ 
          $("html, body").animate({ scrollTop: 0 }, 600); 
          return false; 
      }); 
  });
  
  
  
  let  numberPercent = document.querySelectorAll('.countbar')
  let getPercent = Array.from(numberPercent)
  
  getPercent.map((items) => {
      let startCount = 0
      let progressBar = () => {
          startCount ++
          items.innerHTML = `<h3>${startCount}%</h3>`
          items.style.width = `${startCount}%`
          if(startCount == items.dataset.percentnumber) {
              clearInterval(stop)
          }
      }
      let stop = setInterval(() => {
          progressBar()
      },25)
  })
  
  
  
  
  let question = document.querySelectorAll(".question");
  
  question.forEach(question => {
      question.addEventListener("click", event => {
          const active = document.querySelector(".question.active");
          if (active && active !== question) {
              active.classList.toggle("active");
              active.nextElementSibling.style.maxHeight = 0;
          }
          question.classList.toggle("active");
          const answer = question.nextElementSibling;
          if (question.classList.contains("active")) {
              answer.style.maxHeight = answer.scrollHeight + "px";
          } else {
              answer.style.maxHeight = 0;
          }
      })
  })
  
  
  
  jQuery(document).ready(function($) {
        $('.slider-logo-image').slick({
          dots: false,
          infinite: true,
          speed: 500,
          slidesToShow: 5,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          arrows: true,
          responsive: [{
            breakpoint: 900,
            settings: {
              slidesToShow: 3,
              slidesToScroll: 1
            }
          },
          {
             breakpoint: 400,
             settings: {
                arrows: false,
                slidesToShow: 1,
                slidesToScroll: 1
             }
          }]
      });
  });
  
  
  
  $(document).ready(function () {
      $('.my-slider').slick({
          slidesToShow: 3,
          slidesToScroll: 1,
          arrows: true,
          dots: true,
          speed: 300,
          infinite: true,
          autoplaySpeed: 5000,
          autoplay: true,
          responsive: [
              {
                  breakpoint: 991,
                  settings: {
                      slidesToShow: 2,
                  }
              },
              {
                  breakpoint: 767,
                  settings: {
                      slidesToShow: 1,
                  }
              }
          ]
      });
  });
  
  
  
  
  
  
  const items = document.querySelectorAll('.accordion button');
     function toggleAccordion() {
       const itemToggle = this.getAttribute('aria-expanded');
     
       for (i = 0; i < items.length; i++) {
         items[i].setAttribute('aria-expanded', 'false');
       }
     
       if (itemToggle == 'false') {
         this.setAttribute('aria-expanded', 'true');
       }
     }
     
     items.forEach((item) => item.addEventListener('click', toggleAccordion));
     
  
  
  
  
  function openCity(evt, cityName) {
              var i, tabcontent, tablinks;
              tabcontent = document.getElementsByClassName("tabcontent");
              for (i = 0; i < tabcontent.length; i++) {
                  tabcontent[i].style.display = "none";
              }
              tablinks = document.getElementsByClassName("tablinks");
              for (i = 0; i < tablinks.length; i++) {
                  tablinks[i].className = tablinks[i].className.replace(" active", "");
              }
              document.getElementById(cityName).style.display = "block";
              evt.currentTarget.className += " active";
          }
  
          // Get the element with id="defaultOpen" and click on it
         // document.getElementById("defaultOpen").click();
      
    
    
    
    jQuery(document).ready(function($) {
        $('.slider-DotNet').slick({
          dots: true,
          infinite: true,
          speed: 500,
          slidesToShow: 2,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          arrows: true,
          responsive: [{
            breakpoint: 600,
            settings: {
              slidesToShow: 1,
              slidesToScroll: 1
            }
          },
          {
             breakpoint: 400,
             settings: {
                arrows: true,
                slidesToShow: 1,
                slidesToScroll: 1
             }
          }]
      });
  });
  
  
  
  
  jQuery(document).ready(function($) {
        $('.slider-ruby').slick({
          dots: true,
          infinite: true,
          speed: 500,
          slidesToShow: 2,
          slidesToScroll: 1,
          autoplay: true,
          autoplaySpeed: 2000,
          arrows: true,
          responsive: [{
            breakpoint: 600,
            settings: {
              slidesToShow: 1,
              slidesToScroll: 1
            }
          },
          {
             breakpoint: 400,
             settings: {
                arrows: true,
                slidesToShow: 1,
                slidesToScroll: 1
             }
          }]
      });
  });
  
  jQuery(document).ready(function($) {
    $('.slider-QA').slick({
      dots: false,
      infinite: true,
      speed: 300,
      slidesToShow: 2,
      slidesToScroll: 1,
      autoplay: true,
      autoplaySpeed: 2000,
      arrows: true,
      responsive: [{
        breakpoint: 600,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      },
      {
         breakpoint: 400,
         settings: {
            arrows: true,
            slidesToShow: 1,
            slidesToScroll: 1
         }
      }]
  });
  });


//#region - start of - number counter animation
const counterAnim = (qSelector, start = 0, end, duration = 1000) => {
    const target = document.querySelector(qSelector);
    let startTimestamp = null;
    const step = (timestamp) => {
        if (!startTimestamp) startTimestamp = timestamp;
        const progress = Math.min((timestamp - startTimestamp) / duration, 1);
        target.innerText = Math.floor(progress * (end - start) + start);
        if (progress < 1) {
            window.requestAnimationFrame(step);
        }
    };
    window.requestAnimationFrame(step);
};

document.addEventListener("DOMContentLoaded", () => {
    counterAnim("#count1", 150, 80, 1000);
    counterAnim("#count2", 320, 65, 1500);
    counterAnim("#count3", 100, 10, 2000);
    counterAnim("#count4", 50, 5, 2500);
});


$(function () {
    $(".section-01").hide();

    $(".secList").on("click", function () {
        // クリックした要素の ID と違うクラス名のセクションを非表示
        $(".section-01")
            .not($("." + $(this).attr("id")))
            .hide();
        // クリックした要素の ID と同じクラスのセクションを表示
        $("." + $(this).attr("id")).show(1000);
        $("#fuu").hide();
        // toggle にすると、同じボタンを 2 回押すと非表示になる
        // $('.'+$(this).attr('id')).toggle();
    });
});