"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var restCallHeaders_class_1 = require("./restCallHeaders.class");
var rxjs_1 = require("rxjs");
var BaseService = /** @class */ (function () {
    function BaseService() {
        this.restCallHeaders = new restCallHeaders_class_1.RestCallHeaders();
    }
    Object.defineProperty(BaseService.prototype, "headers", {
        get: function () {
            return this.restCallHeaders.getRequestHeadersForLoggedInUser();
        },
        enumerable: true,
        configurable: true
    });
    BaseService.prototype.handleError = function (error) {
        var applicationError = error.headers.get('Application-Error');
        if (applicationError) {
            return rxjs_1.Observable.throw(applicationError);
        }
        var modelStateErrors = '';
        if (error.status === 413) {
            modelStateErrors = BaseService.PayloadTooLargeErrorMessage;
        }
        else if (error.error) {
            for (var key in error.error) {
                if (error.error[key]) {
                    modelStateErrors += error.error[key] + '\n';
                    console.error(key + ' ' + error.error[key]);
                }
            }
        }
        else if (error.status === 401) {
            modelStateErrors = BaseService.UnauthErrorMessage;
        }
        else if (error.status === 403) {
            modelStateErrors = BaseService.ForbiddenErrorMessage;
        }
        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        return rxjs_1.throwError(modelStateErrors || 'Error while accessing the server. Please contact your system administrator.');
    };
    BaseService.UnauthErrorMessage = "Unauthorized access. Maybe the session has expired. Please log in again.";
    BaseService.ForbiddenErrorMessage = "Forbidden operation was attempted.Please log in.";
    BaseService.PayloadTooLargeErrorMessage = "Downloaded file is too big.";
    return BaseService;
}());
exports.BaseService = BaseService;
//# sourceMappingURL=base.service.js.map