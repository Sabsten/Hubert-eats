import type { UserType } from '@/models/userType';
import { defineStore } from 'pinia';
import jwt_decode from 'jwt-decode';

export type TokenPayload = {
    type: string,
    accountId: string,
}
export const useAuthStore = defineStore({
    id: 'Auth',
    state: () => ({
        auth: '',
    }),
    getters: {
        getAccountId: (state) => {
            const payload = jwt_decode<TokenPayload>(state.auth);
            return payload.accountId;
        },
        getAccountType: (state) => {
            const payload = jwt_decode<TokenPayload>(state.auth);
            return payload.type;
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
                this.auth = '';
                return data.error;
            }
            this.auth = data.token;
            console.log('Request successful');
            return null
        }
    }
})
