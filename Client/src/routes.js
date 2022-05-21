import addTicket from './components/addTicket.vue';
import showTickets from './components/showTickets.vue';
import ticketDetail from './components/ticketDetail.vue';

export default [
    { path: '/', component: showTickets},
    { path: '/add', component: addTicket},
    { path: '/ticket/:id', component: ticketDetail}
]
