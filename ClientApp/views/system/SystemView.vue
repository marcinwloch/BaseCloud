<template>
<div>
    <el-row>
    here
    </el-row>

    <router-link :to="{ name: 'dashboardPage' }" exact>dashboard</router-link>
    <router-link :to="{ name: 'settings' }">settings</router-link>
    <el-row>
       <router-view></router-view>
    </el-row>
 
</div>
</template>

<script>

    import dashboard from 'views/system/pages/DashboardPage'
    import settings from 'views/system/pages/SettingsPage'
    import router from 'vue-router'
    
export default {
    name: 'System',
    components:
    {
        dashboard,settings
    },
    data() {
        return {

        }
    },    
    mounted() {
        console.log("system");
    },
    methods: {

    }
}
</script>

<style>

</style>