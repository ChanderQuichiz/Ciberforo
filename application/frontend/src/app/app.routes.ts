import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'home',
        loadComponent: () => import('./pages/home/home').then((m) => m.Home),

    },
    {
        path: 'comments',
        loadComponent: () => import('./pages/comments/comments').then((m) => m.Comments),
    },
    {
        path: '',
        loadComponent: () => import('./pages/login/login').then((m) => m.Login),
    },
    {
        path: 'register',
        loadComponent: () => import('./pages/register/register').then((m) => m.Register),
    },
    {
        path: 'profile',
        loadComponent: () => import('./pages/profile/profile').then((m) => m.Profile),
    }
];
