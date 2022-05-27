<template>
    <div>
        <app-header></app-header>
        <router-view></router-view>
    </div>
</template>

<script>
// Imports
import header from './components/appHeader.vue';
import { CapacitorUpdater } from '@capgo/capacitor-updater'

export default {
    components: {
        'app-header': header
    },
    data () {
        return {

        }
    },
    created(){
        CapacitorUpdater.notifyAppReady()
    },
    methods: {

    }
}
</script>

<style>
body{
    margin: 0;
    font-family: 'Nunito SemiBold';
}
</style>
