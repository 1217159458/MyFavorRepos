(this.webpackJsonptest=this.webpackJsonptest||[]).push([[0],{15:function(e,t,n){"use strict";n.r(t);var c=n(4),i=n(2),l=n(13),o=n.n(l),s=(n(20),n(14)),u=n.n(s),r=n(1),a=!1,j=document.getElementById("root");function d(){var e=Object(i.useState)([]),t=Object(c.a)(e,2),n=t[0],l=t[1],o=Object(i.useState)([]),s=Object(c.a)(o,2),j=s[0],d=s[1];return Object(i.useEffect)((function(){a||(a=!0,u.a.get("http://localhost:8081/logs").then((function(e){l(e.data.map((function(e){return e.Level})))})).catch((function(e){console.log(e)})))})),Object(r.jsxs)("div",{className:"container",children:[Object(r.jsx)("div",{className:"left",children:Object(r.jsx)("select",{multiple:!0,id:"left",children:n.map((function(e){return Object(r.jsx)("option",{value:e,onDoubleClick:function(){f()},children:e},e)}))})}),Object(r.jsxs)("div",{className:"middle",children:[Object(r.jsx)("button",{type:"button",onClick:function(){f()},children:">>"}),Object(r.jsx)("button",{type:"button",onClick:function(){b()},children:"<<"})]}),Object(r.jsx)("div",{className:"right",children:Object(r.jsx)("select",{multiple:!0,id:"right",children:j.map((function(e){return Object(r.jsx)("option",{value:e,onDoubleClick:function(){b()},children:e},e)}))})})]});function f(){var e=document.getElementById("left").value;if(e){var t=n.slice().filter((function(t){return e!==t}));l(t),j.push(e),d(j)}else alert("select a item to move")}function b(){var e=document.getElementById("right").value;if(e){var t=j.slice().filter((function(t){return e!==t}));d(t),n.push(e),l(n)}else alert("select a item to move")}}o.a.render(Object(r.jsx)(d,{}),j)},20:function(e,t,n){}},[[15,1,2]]]);
//# sourceMappingURL=main.4ce34ed4.chunk.js.map