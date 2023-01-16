import { defineStore } from 'pinia';
import jwt_decode from 'jwt-decode';

export type TokenPayload = {
    type: string,
    accountId: string,
}

function getTokenPayload(): TokenPayload | null {
    const token = localStorage.getItem('TOKEN');
    if(token === null) {
        return null
    }
    return jwt_decode<TokenPayload>(token);
}

export const useAuthStore = defineStore({
    id: 'Auth',
    getters: {
        getAccountId: (): string | null => {
            const payload = getTokenPayload();
            return payload === null ? null : payload.accountId;
        },
        getAccountType: (): string | null => {
            const payload = getTokenPayload();
            return payload === null ? null : payload.type;
        },
        getToken: (): string | null => {
            return localStorage.getItem('TOKEN');
        }
    },
    actions: {
        async signIn(type: string, mail: string, password: string): Promise<string | null> {
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/signin/' + type;
            const RES: Response = await fetch(URL, {
                method: "POST",
                headers: {"Content-Type": "application/json"},
                body: JSON.stringify({mail: mail, password: password})
            });
            const data = await RES.json();
            if (!RES.ok) {
                return data.error;
            }
            localStorage.setItem('TOKEN',data.token)
            console.log('Request successful');
            return null
        },
    }
})