import { Routes } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { ApplicationPageComponent } from './application-page/application-page.component';
import { SupervisorPageComponent } from './supervisor-page/supervisor-page.component';

export const routes: Routes = [
    {
        path:'main',
        component: MainPageComponent
    },
    {
        path:'application/:albumNumber',
        component: ApplicationPageComponent
    },
    {
        path:"SupervisorOrder",
        component: SupervisorPageComponent
    }
];
