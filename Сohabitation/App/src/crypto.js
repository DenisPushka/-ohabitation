import CryptoJS from "crypto-js";
import config from "./public/config.json";

/**
 * Шифровальщик.
 * */
class Crypto {
    
    /**
     * @param {String} text Строка для шифрования.
     * @return {Object} закодированный объект.*/
    decryptStringAes(text) {
        let key = CryptoJS.enc.Utf8.parse(config.key);
        let iv = CryptoJS.enc.Utf8.parse(config.key);

        return CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(text), key,
            {keySize: 16, iv: iv, mode: CryptoJS.mode.CBC, padding: CryptoJS.pad.Pkcs7});
    }
}

export default Crypto;