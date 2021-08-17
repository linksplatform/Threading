namespace Platform::Threading::Tests
{
    TEST_CLASS(ThreadHelpersTests)
    {
        public: TEST_METHOD(InvokeTest)
        {
            auto number = 0;
            ThreadHelpers.InvokeWithExtendedMaxStackSize([&]()-> auto { return number = 1; });
            Assert::AreEqual(1, number);
            ThreadHelpers.InvokeWithExtendedMaxStackSize(2, param { return number = (std::int32_t)param); }
            Assert::AreEqual(2, number);
            ThreadHelpers.InvokeWithModifiedMaxStackSize([&]()-> auto { return number = 1; }, maxStackSize: 512);
            Assert::AreEqual(1, number);
            ThreadHelpers.InvokeWithModifiedMaxStackSize(2, param { return number = (std::int32_t)param, maxStackSize: 512); }
            Assert::AreEqual(2, number);
        }
    };
}
