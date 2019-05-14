"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var RestCallHeaders = /** @class */ (function () {
    function RestCallHeaders() {
    }
    RestCallHeaders.prototype.getRequestHeadersForLoggedInUserWithCustomHeaders = function (customHeaders) {
        return new http_1.HttpHeaders(customHeaders);
    };
    RestCallHeaders.prototype.getRequestHeadersForLoggedInUser = function () {
        return this.getRequestHeadersForLoggedInUserWithCustomHeaders({ 'Content-Type': 'application/json' });
    };
    return RestCallHeaders;
}());
exports.RestCallHeaders = RestCallHeaders;
//# sourceMappingURL=restCallHeaders.class.js.map