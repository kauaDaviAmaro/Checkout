import http from "./http";

class ShippingDataService {
    addShipping(shipping) {
        return http.post("/shipping", shipping);
    }
}

export default new ShippingDataService()