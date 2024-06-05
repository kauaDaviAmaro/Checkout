import http from "./http";

class ContactDataService {
    async createContact(contact) {
        return await http.post("/contact", contact).then((response) => {
            return response.data;
        });
    }
}

export default new ContactDataService();