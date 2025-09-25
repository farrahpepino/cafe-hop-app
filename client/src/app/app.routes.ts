import { Routes } from '@angular/router';
import { Auth } from './components/auth/auth';
import { Home } from './components/home/home';

export const routes: Routes = [
    {
        path: '',
        component: Auth
    },
    {
        path: 'home',
        component: Home
    }
];
