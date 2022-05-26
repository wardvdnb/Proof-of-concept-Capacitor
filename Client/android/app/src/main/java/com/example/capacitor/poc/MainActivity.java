package com.example.capacitor.poc;

import android.net.http.SslError;
import android.os.Bundle;
import android.webkit.SslErrorHandler;
import android.webkit.WebView;

import com.getcapacitor.BridgeActivity;
import com.getcapacitor.BridgeWebViewClient;
import com.getcapacitor.Plugin;

import java.util.ArrayList;

public class MainActivity extends BridgeActivity {
//    @Override
//    public void onCreate(Bundle savedInstanceState) {
//        super.onCreate(savedInstanceState);
//
//        this.init(savedInstanceState, new ArrayList<Class<? extends Plugin>>() {{
//            // Additional plugins you've installed go here
//            // Ex: add(TotallyAwesomePlugin.class);
//        }});
//
//        if (BuildConfig.DEBUG) {
//            this.bridge.getWebView().setWebViewClient(new BridgeWebViewClient(this.bridge) {
//                @Override
//                public void onReceivedSslError(WebView view, final SslErrorHandler handler, SslError error) {
//                    handler.proceed();
//                }
//            });
//        }
//    }
}
